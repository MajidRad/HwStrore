import axios, { AxiosResponse } from "axios";
import { toast } from "react-toastify";
import { ErrorResponse } from "../model/ErrorResponse";
import { store } from "../store/configureStore";
import { history } from "../layout/App";
import { URLSearchParams } from "url";

axios.defaults.baseURL = "http://localhost:5000/api/";
axios.defaults.withCredentials = true;
const responseBody = (response: AxiosResponse) => response.data;
axios.interceptors.request.use((config: any) => {
  const token = store.getState().account.User?.token;
  if (token) config.headers.Authorization = `Bearer ${token}`;
  return config;
});

axios.interceptors.response.use(
  (response: AxiosResponse) => {
    console.log(response.data);
    return response;
  },
  (error: ErrorResponse) => {
    const { data, status } = error.response;
    switch (status) {
      case 400:
        if (data.errors) {
          const modelStateErrors: string[] = [];
          for (const key in data.errors) {
            if (data.errors[key]) {
              modelStateErrors.push(data.errors[key]);
            }
          }
          throw modelStateErrors;
        }
        toast.error(data.title);
        break;
      case 401:
        toast.error("Not Authorized");
        break;
      case 403:
        toast.error("You are not allow to do that!");
        break;
      case 404:
        toast.error(data.title);
        break;
      case 500:
        history.push("/server-error", error);
        break;
      default:
        break;
    }
    return Promise.reject(error.response);
  }
);

const request = {
  get: (url: string, params?: URLSearchParams) =>
    axios.get(url, { params, withCredentials: true }).then(responseBody),
  post: (url: string, body: {}) =>
    axios.post(url, body, { withCredentials: true }).then(responseBody),
  put: (url: string, body: {}) => axios.put(url, body).then(responseBody),
  delete: (url: string) => axios.delete(url).then(responseBody),
};
const Product = {
  getAll: (params: URLSearchParams) => request.get("/product", params),
  details: (id: number) => request.get(`product/${id}`),
};
const Basket = {
  get: () => request.get("Basket/GetBasket"),
  addItem: (productId: number, quantity = 1) =>
    request.post(
      `Basket/AddItem?productId=${productId}&quantity=${quantity}`,
      {}
    ),
  removeItem: (productId: number, quantity: number = 1) =>
    request.delete(
      `Basket/RemoveItem?productId=${productId}&quantity=${quantity}`
    ),
  updateItem: (buyerId: string, productId: number, quantity: number) =>
    request.put(
      `Basket/UpdateBasket?buyerId=${buyerId}&productId=${productId}&quantity=${quantity}`,
      {}
    ),
};
const Account = {
  login: (values: any) => request.post("Account/Login", values),
  register: (values: any) => request.post("Account/Register", values),
  currentUser: () => request.get("Account/CurrentUser"),
};
const agent = {
  Account,
  Product,
  Basket,
};
export default agent;
