import { PetCard } from "../../Components/PetCard";
import { v4 as uuidv4 } from 'uuid';
import PetForm from "../../Components/PetForm";
import { AnimalSpecies } from "../../Enums/AnimalSpecies";
import { Pet } from "../../Models/Pet";
import './mypets.css'
import { TOKEN_KEY, getEmail, getToken } from "../../Services/auth";
import { useEffect, useState } from "react";
import { petGuardianApi } from "../../Services/petGuardianApi";
import { User } from "../../Models/User";




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

export function MyPets() {
  const [userData, setUserData] = useState<User>(new User("", "", ""));
  const [showForm, setShowForm] = useState(false);
  const [name, setName] = useState('');
  //TROCAR PARA COOKIES DEPOIS - EXISTE UMA OPÇÃO PARA O COOKIE VENCER CONFORME O TEMPO DE EXPIRAÇÃO DEFINIDO NA API
  var token = getToken();

  if (!token) {
    token = ''
  }
  const decodedToken = JSON.parse(atob(token.split('.')[1]));
  var userIdentity = decodedToken.id
  var email = decodedToken.email

  useEffect(() => {
    const fetchUserById = async () => {
      try {
        const request = await petGuardianApi.post(`/User/get_user?userId=${userIdentity}`);
        setUserData(request.data);

      } catch (error) {
        console.log("New ERRO" + error)
        setShowForm(true); // Mostrar o formulário se o usuário não for encontrado
      }
    };

    fetchUserById();
  }, [userIdentity]);


  // Lógica para enviar o nome do usuário para o backend
  const handleNameSubmit = async (e: React.FormEvent<HTMLFormElement>) => {
    e.preventDefault();
    try {
      const response = await petGuardianApi.post('/User/create_user', { userIdentity, name, email })
      console.log(response.data);

    } catch (err) {
      console.log("Erro: " + err);

    }
    // Após o envio bem-sucedido, atualizar o estado para esconder o formulário
    setShowForm(false);
  };

  //---FIM DA FUNÇÃO QUE VERIFICA O USUARIO E CADASTRA


  //AQUI INICIA A FUNÇÃO PARA BUSCAR OS PETS NO BANCO DE DADOS
  const simulatedPets: Pet[] = [
    new Pet(uuidv4(), 'Max', 'M', AnimalSpecies.Dog, new Date('2020-01-15'), 12.5, 'User1'),
    new Pet(uuidv4(), 'Bella', 'F', AnimalSpecies.Cat, new Date('2019-05-03'), 8.2, 'User2'),
    new Pet(uuidv4(), 'Charlie', 'M', AnimalSpecies.Dog, new Date('2021-02-20'), 15.8, 'User3'),
    new Pet(uuidv4(), 'Lucy', 'F', AnimalSpecies.Cat, new Date('2020-10-10'), 7.3, 'User1'),
    new Pet(uuidv4(), 'Cooper', 'M', AnimalSpecies.Dog, new Date('2018-12-08'), 20.0, 'User4'),
    new Pet(uuidv4(), 'Luna', 'F', AnimalSpecies.Cat, new Date('2019-08-25'), 9.5, 'User2'),
    new Pet(uuidv4(), 'Lana', 'F', AnimalSpecies.Cat, new Date('2020-10-10'), 7.3, 'User1'),
    new Pet(uuidv4(), 'Mark', 'M', AnimalSpecies.Dog, new Date('2018-12-08'), 20.0, 'User4'),
    new Pet(uuidv4(), 'Jack', 'F', AnimalSpecies.Cat, new Date('2019-08-25'), 9.5, 'User2'),
  ];

  //FUNÇÃO GETALL TERMINA AQUI

  return (
    <>
      <div>
        {showForm ? (
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
        ) : null}
      </div>
      <div className="pet-container">

        <h1>Confira seus Pets Aqui</h1>
        <section className="pets-cards">
          <PetCard petList={simulatedPets} />
        </section>
        <div className="addpet">
          <h2>Adicione o Pet</h2>

          <PetForm />
        </div>

      </div>
    </>
  )
}