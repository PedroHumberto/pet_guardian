import { PetCard } from "../../Components/PetCard";
import { v4 as uuidv4 } from 'uuid';
import PetForm from "../../Components/PetForm";
import './mypets.css'
import { TOKEN_KEY, getEmail, getToken } from "../../Services/auth";
import { petGuardianApi } from '../../Services/petGuardianApi';
import { useEffect, useState } from "react";




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
  const [pets, setPets] = useState<any>([]);


  //TROCAR PARA COOKIES DEPOIS - EXISTE UMA OPÇÃO PARA O COOKIE VENCER CONFORME O TEMPO DE EXPIRAÇÃO DEFINIDO NA API
  var token = getToken();

  if (!token) {
    token = ''
  }
  const decodedToken = JSON.parse(atob(token.split('.')[1]));
  var userId = decodedToken.id
  var email = decodedToken.email

  useEffect(() => {
    const fetchPets = async () => {
      const petResponse = await petGuardianApi.get(`/Pet/get_pet_by_userId?userId=${userId}`)
      console.log("Pet Reponse " + petResponse.data[0].petName)
      setPets(petResponse.data)
    }
    fetchPets()
  }, []);
   

  //DEVO COLOCAR OS DEMAIS ATRIBUTOS NOS PETS COMO MEDICINE
  //petName: 'Luci', gender: 'F', specie: 1, birthDate: '2023-11-27T23:37:39.13', age: 0, …}
  // age : 0

  // birthDate : "2023-11-27T23:37:39.13"
  // gender : "F"
  // medicines : []
  // petName : "Luci"
  // specie 1
  // weight : 14
  console.log(pets[0]);

  //FUNÇÃO GETALL TERMINA AQUI

  return (
    <>
      <div className="mypets-container">
        
            <PetCard petList={pets} />

      </div>
      <div className="addpet">
            <h2>Adicione o Pet</h2>
            <PetForm />
      </div>
    </>
  )
}