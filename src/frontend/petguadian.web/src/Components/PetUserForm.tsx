import { useState } from "react";
import { petGuardianApi } from "../Services/petGuardianApi";
import { User } from "../Models/User";
import { getToken } from "../Services/auth";



export function PetUserForm() {
    const [name, setName] = useState('');
    const [userData, setUserData] = useState<User>(new User("", "", ""));

    var token = getToken();

    if (!token) {
      token = ''
    }
    const decodedToken = JSON.parse(atob(token.split('.')[1]));
    var userIdentity = decodedToken.id
    var email = decodedToken.email


    const handleNameSubmit = async (e: React.FormEvent<HTMLFormElement>) => {
        e.preventDefault();
        try {
            const response = await petGuardianApi.post('/User/create_user', { userIdentity, name, email })
            console.log(response.data);

        } catch (err) {
            console.log("Erro: " + err);

        }
        // Após o envio bem-sucedido, atualizar o estado para esconder o formulário
    };

    return (
        <>
            <form onSubmit={handleNameSubmit}>
                <label>
                    Nome do Usuário:
                    <input
                        type="text"
                        value={name}
                        onChange={(e) => setName(e.target.value)}
                    />
                </label>
                <button type="submit">Enviar</button>
            </form>
        </>
    )
}