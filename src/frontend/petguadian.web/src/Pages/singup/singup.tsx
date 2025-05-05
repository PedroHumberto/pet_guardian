import { useState } from "react";
import styles from './singup.module.css';
import singupImage from '../../assets/minimalist-pet2-nobackground.png'


import { IdentiTyApi } from "../../Services/identityApi";
import { useNavigate } from "react-router-dom";


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
  <div className={styles.container}>
    <div className={styles.subcontainer}>
      <div className={styles.userForm}>
        <h1>Cadastre-se</h1>
        <form onSubmit={handleSubmit}>
          <label>
            <p>Nome:</p>
            <input
              className={styles.customInput}
              type="text"
              name="userName"
              value={user.userName}
              placeholder="Digite seu nome"
              onChange={handleInputChange}
              required
            />
          </label>
          <label>
            <p>Email</p>
            <input
              className={styles.customInput}
              type="text"
              name="email"
              placeholder="Digite seu Email"
              value={user.email}
              onChange={handleInputChange}
              required
            />
          </label>
          <label>
            <p>Senha:</p>
            <input
              className={styles.customInput}
              type="password"
              name="password"
              placeholder="Digite sua Senha"
              value={user.password}
              onChange={handleInputChange}
              required
            />
          </label>
          <label>
            <p>Confirme a Senha:</p>
            <input
              className={styles.customInput}
              type="password"
              name="rePassword"
              placeholder="Repita a Senha"
              value={user.rePassword}
              onChange={handleInputChange}
              required
            />
          </label>
          
          <button type="submit">CADASTRAR</button>
          <div className={styles.loginLink}>
            <a href="/login">Já Possui Cadastro? Clique Aqui</a>
          </div>
        </form>
      </div>
      <img src={singupImage} alt="imagem de pets minimalistas" />
    </div>
</div>

  );
}

export default Singup;