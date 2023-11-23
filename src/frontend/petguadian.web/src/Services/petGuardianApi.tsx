import axios from "axios";

export const petGuardianApi = axios.create({
  baseURL: "https://localhost:7057/api/"
});


