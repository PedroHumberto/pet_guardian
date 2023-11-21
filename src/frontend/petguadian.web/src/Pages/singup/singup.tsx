import { useState } from "react";
import { User } from "../../Models/User";
import { UserLogin } from "../../Models/UserLogin";




export function  Singup()
{
    const [user, setUser] = useState({
        email: '',
        password: '',
        rePassword: ''
      });

    const [singUpErrors, setSingUpErrors] = useState<string[]>([])
    

      const handleInputChange = (e: React.ChangeEvent<HTMLInputElement | HTMLSelectElement>) => {
        const { name, value } = e.target;
        setUser({ ...user, [name]: value });
      };
    
      const handleSubmit = (e: React.FormEvent<HTMLFormElement>) => {
        e.preventDefault();
        
        //FUNÇÃO DE CADASTRAR--------------------
        const url = "https://localhost:7182/User/singup"
        
        var formData = new FormData();
        formData.append('json1', JSON.stringify(user));
        fetch(url, {
            method: 'POST',
            mode: 'cors',
            headers: {
                'Content-Type': 'application/json',
            },
            body: JSON.stringify(user)
        })
        .then(resp => {
           
              return resp.json();
        })
        .then((data) => {

            //SISTEMA ESTA PUXANDO ERROS DIFERENTES 
            for(const error in data.errors){
                console.log(data.errors[error])
            }
            //--------------
            if(!data.succeeded){
                
                const errors: string[] = []
                //-----AQUI APENAS TRATA ERRO DE USUARIO JÁ EXISTENTE
                for(const error in data.errors){
                    errors.push(data.errors[error].description)
                    
                }
                setSingUpErrors(errors)
                
            }else{
                
                console.log('User registered:', data.succeeded);
                // You can handle the response data here
            }
            
        })
        .catch((error) => {
            console.log('Error registering user:', error);
        })
        //-------------------------------------
      };
    
      return (
        <>
            <>
              <div className="userSingUpForm">
                <div className="userForm">
                  <h2>Cadastro de Usuario</h2>
                  <form onSubmit={handleSubmit}>

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
            </>
        </>
      );
}