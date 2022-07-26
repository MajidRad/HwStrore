import {
  BrowserRouter as Router,
  unstable_HistoryRouter as HistoryRouter,
  Route,
  Routes,
  Outlet,
} from "react-router-dom";
import { createBrowserHistory } from "history";
import HomePage from "../../features/home/HomePage";
import Login from "../../features/account/Login";
import Register from "../../features/account/Register";
import Header from "../layout/Header";
import {
  Container,
  createTheme,
  CssBaseline,
  ThemeProvider,
} from "@mui/material";
import ProductList from "../../features/Product/ProductList";
import { useCallback, useEffect, useState } from "react";
import { useAppDispatch } from "../store/configureStore";
import { fetchCurrentUser } from "../../features/account/accountSlice";
import ProductDetails from "../../features/Product/ProductDetails";
import { fetchBasketAsync } from "../../features/basket/basketSlice";
import { ToastContainer } from "react-toastify";
import "react-toastify/dist/ReactToastify.css";
export const history = createBrowserHistory({ window });
const NavLayout = () => (
  <>
    <Header />
    <Container>
      <Outlet />
    </Container>
  </>
);
const App = () => {
  const [darkMode, setDarkMode] = useState(false);
  const paletteType = darkMode ? "dark" : "light";
  const theme = createTheme({
    palette: {
      mode: paletteType,
      background: {
        default: paletteType === "light" ? "#eaeaea" : "#121212",
      },
    },
  });
  const dispatch = useAppDispatch();
  const initApp = useCallback(async () => {
    try {
      await dispatch(fetchBasketAsync());
      await dispatch(fetchCurrentUser());
    } catch (error: any) {
      console.log(error);
    }
  }, [dispatch]);
  useEffect(() => {
    initApp();
  }, [initApp]);

  return (
    <>
      <ToastContainer position="bottom-right" hideProgressBar theme="colored" />
      <CssBaseline />
      <HistoryRouter history={history}>
        <Routes>
          <Route path="" element={<NavLayout />}>
            <Route path="/" element={<HomePage />} />
            <Route path="/login" element={<Login />} />
            <Route path="/register" element={<Register />} />
            <Route path="/products" element={<ProductList />} />
            <Route path="Products/:id" element={<ProductDetails />} />
          </Route>
        </Routes>
      </HistoryRouter>
    </>
  );
};

export default App;
