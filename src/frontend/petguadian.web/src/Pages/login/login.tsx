import { useState } from "react";
import { UserLogin } from "../../Models/UserLogin";
import { Link, useNavigate } from 'react-router-dom';
import { login } from "../../Services/auth";
import { IdentiTyApi } from "../../Services/identityApi";


export function Login() {
  const [user, setUser] = useState({
    email: '',
    password: '',
    error: ""
  });
  const navigate = useNavigate();

  const handleInputChange = (e: React.ChangeEvent<HTMLInputElement | HTMLSelectElement>) => {
    const { name, value } = e.target;
    setUser({ ...user, [name]: value });
  };

  const handleLogin = async (e: React.FormEvent<HTMLFormElement>) => {
    e.preventDefault();

    const userModel = new UserLogin(
      user.email,
      user.password
    );
    const {email, password} = userModel

    try{
      const response = await IdentiTyApi.post("/login", {email, password});
      console.log("Response: ", response.data)
      login(response.data);
      navigate("/mypets");

    }catch(err)
    {
      console.log(err);
    }
  };


  return (
    <>
      <>
        <div className="userSingUpForm">
          <div className="userForm">
            <h2>Cadastro de Usuario</h2>
            <form onSubmit={handleLogin}>

              <label>
                Email:
                <input
                  type="text"
                  name="email"
                  value={user.email}
                  onChange={handleInputChange}
                  required
                />
              </label>
              <label>
                Senha:
                <input
                  type="password"
                  name="password"
                  value={user.password}
                  onChange={handleInputChange}
                  required
                />
              </label>

              <div className="addAndCloseBtns">
                <button type="submit">LOGIN</button>
              </div>
            </form>
          </div>
        </div>
      </>
    </>
  );
}