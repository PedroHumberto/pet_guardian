import axios from "axios";
import { getToken } from "./auth";

export const IdentiTyApi = axios.create({
  baseURL: "https://localhost:7182/User/"
});

IdentiTyApi.interceptors.request.use(async config => {
  const token = getToken();
  if (token) {
    config.headers.Authorization = `Bearer ${token}`;
  }
  return config;
});
