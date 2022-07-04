import axios, { AxiosResponse } from "axios";


axios.defaults.baseURL = "http://localhost:5000/";
const responseBody = <T>(response: AxiosResponse<T>) => response.data;

const request = {
  get: (url: string, params?: URLSearchParams) =>
    axios.get(url, { params }).then(responseBody),
  post: (url: string, body: {}) => axios.post(url, body).then(responseBody),
  put: (url: string, body: {}) => axios.put(url, body).then(responseBody),
  delete: (url: string) => axios.delete(url).then(responseBody),
};
const Product={
  getAll:()=>request.get("/")
}
const Account = {
  login: (values: any) => request.post("Account/login", values),
  register: (values: any) => request.post("Account/Register", values),
  currentUser: () => request.get("Account/CurrentUser"),
};
const agent = {
  Account,
};
export default agent;
