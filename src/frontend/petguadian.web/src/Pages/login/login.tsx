import { useState } from "react";
import { UserLogin } from "../../Models/UserLogin";

interface JWTParts {
  header: any;
  payload: any;
}

function formatarJWT(jwt: string): JWTParts {
  const partes = jwt.split('.');

  if (partes.length !== 3) {
    throw new Error('Formato JWT inválido');
  }

  const [headerBase64, payloadBase64] = partes;

  const header = JSON.parse(atob(headerBase64));
  const payload = JSON.parse(atob(payloadBase64));

  return { header, payload };
}

// Exemplo de uso:



export function Login() {
  const [user, setUser] = useState({
    email: '',
    password: ''
  });

  const handleInputChange = (e: React.ChangeEvent<HTMLInputElement | HTMLSelectElement>) => {
    const { name, value } = e.target;
    setUser({ ...user, [name]: value });
  };

  const handleLogin = (e: React.FormEvent<HTMLFormElement>) => {
    e.preventDefault();

    const userModel = new UserLogin(
      user.email,
      user.password
    );

    //FUNÇÃO PARA ACESSA R A API
    const url = "https://localhost:7182/User/login"

    var formData = new FormData();
    formData.append('json1', JSON.stringify(userModel));

    fetch(url, {
      method: 'POST',
      mode: 'cors',
      headers: {
        'Content-Type': 'application/json',
      },
      body: JSON.stringify(userModel)
    })
      .then(resp => resp.text()) // Alterado de .json() para .text()
      .then((token) => {


        try {
          const { header, payload } = formatarJWT(token);
          console.log('Cabeçalho:', header);
          console.log('Payload:', payload);
          const decodedToken = JSON.parse(atob(token.split('.')[1]));
          console.log(decodedToken.id)
          console.log(decodedToken.role)
        } 
        catch (error)  {
          console.error('Erro:', error);
        }
      })
      .catch((error) => {
        console.log('Error logging in user:', error);
      });



    //------------------------


    console.log(userModel);
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