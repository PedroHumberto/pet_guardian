import { useState } from "react";
import { User } from "../../Models/User";
import { UserLogin } from "../../Models/UserLogin";
import { IdentiTyApi } from "../../Services/identityApi";
import { useNavigate } from "react-router-dom";
import './singup.css'


export const Singup = () => {
  const [user, setUser] = useState({
    userName: '',
    email: '',
    password: '',
    rePassword: ''
  });

  const [singUpErrors, setSingUpErrors] = useState<string[]>([])
  const navigate = useNavigate();

  const handleInputChange = (e: React.ChangeEvent<HTMLInputElement | HTMLSelectElement>) => {
    const { name, value } = e.target;
    setUser({ ...user, [name]: value });
  };

  const handleSubmit = async (e: React.FormEvent<HTMLFormElement>) => {
    e.preventDefault();

    const { userName, email, password, rePassword } = user

    try {
      const response = await IdentiTyApi.post("/singup", { userName, email, password, rePassword });
      console.log(response.data);
      navigate("/login")
    } catch (err) {
      console.log(err)
    }
  };

  return (
    <div className="user-form-container">
      <div className="userForm">
        <h2>Cadastro de Usuario</h2>
        <form onSubmit={handleSubmit}>
          <label>
            Name:
            <input
              type="text"
              name="userName"
              value={user.userName}
              onChange={handleInputChange}
              required
            />
          </label>
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
          <label>
            Senha:
            <input
              type="password"
              name="rePassword"
              value={user.rePassword}
              onChange={handleInputChange}
              required
            />
          </label>
          <div className="addAndCloseBtns">
            <button type="submit">CADASTRAR</button>
            <h1>{singUpErrors}</h1>
          </div>
        </form>
      </div>
    </div>

  );
}

export default Singup;