export const TOKEN_KEY = "@petguardian-Token";
export const EMAIL_KEY = "@petguardian-email";
export const getEmail = () => localStorage.getItem(EMAIL_KEY)
export const isAuthenticated = () : boolean => localStorage.getItem(TOKEN_KEY) !== null;
export const getToken = () => localStorage.getItem(TOKEN_KEY);
export const login = (token: string) => {
  localStorage.setItem(TOKEN_KEY, token);
};
export const logout = () => {
  localStorage.removeItem(TOKEN_KEY);
};