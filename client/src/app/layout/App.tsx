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
import { Container } from "@mui/material";
const history = createBrowserHistory({ window });
const NavLayout = () => (
  <>
    <Header />
    <Container>
      <Outlet />
    </Container>
  </>
);
const App = () => {
  return (
    <HistoryRouter history={history}>
      <Routes>
        <Route path="" element={<NavLayout />}>
          <Route path="/" element={<HomePage />} />
          <Route path="/login" element={<Login/>} />
          <Route path="/register" element={<Register />} />
        </Route>
      </Routes>
    </HistoryRouter>
  );
};

export default App;
