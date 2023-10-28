import { useState } from "react";
import { UserLogin } from "../../Models/UserLogin";

export function Login(){
    const [user, setUser] = useState({
        id: '',
        email: '',
        password: ''
      });    
    
      const handleInputChange = (e: React.ChangeEvent<HTMLInputElement | HTMLSelectElement>) => {
        const { name, value } = e.target;
        setUser({ ...user, [name]: value });
      };
    
      const handleSubmit = (e: React.FormEvent<HTMLFormElement>) => {
        e.preventDefault();

        //FUNÇÃO PARA ACESSAR A API
          
        //------------------------
        const userModel = new UserLogin(
          user.id,
          user.email,
          user.password
        );

        console.log(userModel);
      };
    
      return (
        <>
            <>
              <div className="userSingUpForm">
                <div className="userForm">
                  <h2>Login</h2>
                  <form onSubmit={handleSubmit}>
                    <label>
                      Nome do Usuario:
                      <input
                        type="text"
                        name="name"
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
                      <button type="submit">CADASTRAR</button>
                    </div>
                  </form>
                </div>
              </div>
            </>
        </>
      );
}