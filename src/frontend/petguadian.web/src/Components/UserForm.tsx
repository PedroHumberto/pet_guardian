import { useEffect, useState } from "react"
import './css/petform.css'
import { CreateUserViewModel } from "../ViewModels/UserViewModels/CreateUserViewModel";
import { CreateAddressViewModel } from "../ViewModels/AddressViewModels/CreateAddressViewModel";


export function UserForm() {
  const [userData, setUserData] = useState({
    id: '',
    name: '',
    email: '',
    addressId: '',
  });

  const [addressData, setAddressData] = useState({
    street: '',
    number: '',
    complement: '',
    neighborhood: '',
    city: '',
    state: '',
    postalCode: ''
  })

  const handleUserChange = (e: React.ChangeEvent<HTMLInputElement | HTMLSelectElement>) => {
    const { name, value } = e.target;
    setUserData({ ...userData, [name]: value });
  };

  const handleAddressChange = (e: React.ChangeEvent<HTMLInputElement | HTMLSelectElement>) => {
    const { name, value } = e.target;
    setAddressData({ ...addressData, [name]: value });
  };
  const createAddress = async (creatAddress: CreateAddressViewModel): Promise<string> => {
    const urlAddress = "https://localhost:7182/User/create_address";
    const formDataAddress = new FormData();
    formDataAddress.append('json1', JSON.stringify(creatAddress));
  
    try {
      const responseAddress = await fetch(urlAddress, {
        method: 'POST',
        mode: 'cors',
        headers: {
          'Content-Type': 'application/json',
        },
        body: JSON.stringify(creatAddress),
      });
  
      if (!responseAddress.ok) {
        throw new Error(`Failed with status: ${responseAddress.status}`);
      }
      const dataAddress = await responseAddress.json();
      
      if (!dataAddress.succeeded) {
        throw new Error('Failed to create address');
      } else {
        console.log('Address created:', dataAddress.succeeded);
        return dataAddress.data.id;
      }
    } catch (error) {
      console.error('Error creating address:', error);
      throw new Error('Failed to create address');
    }
  };
  
  const createUser = async (createUser: CreateUserViewModel): Promise<void> => {
    const urlUser = "https://localhost:7182/User/create_user";
    const formDataUser = new FormData();
    formDataUser.append('json1', JSON.stringify(createUser));
  
    try {
      const responseUser = await fetch(urlUser, {
        method: 'POST',
        mode: 'cors',
        headers: {
          'Content-Type': 'application/json',
        },
        body: JSON.stringify(createUser),
      });
  
      if (!responseUser.ok) {
        throw new Error(`Failed with status: ${responseUser.status}`);
      }
  
      const dataUser = await responseUser.json();
  
      if (!dataUser.succeeded) {
        throw new Error('Failed to create user');
      } else {
        console.log('User created:', dataUser.succeeded);
      }
    } catch (error) {
      console.error('Error creating user:', error);
      throw new Error('Failed to create user');
    }
  };

  
  const handleSubmit = async (e: React.FormEvent<HTMLFormElement>) => {
    e.preventDefault();

    try {
      const creatAddress = new CreateAddressViewModel(
        addressData.street,
        addressData.number,
        addressData.complement,
        addressData.neighborhood,
        addressData.city,
        addressData.state,
        addressData.postalCode
      )
      const addressId = await createAddress(creatAddress);
      

      const user = new CreateUserViewModel(
        userData.id,
        userData.name,
        userData.email,
        addressId
      );
      await createUser(user);
      console.log("ENDEREÇO E USUARIOS CRIADOS COM SUCESSO")
    } catch (error) {
      console.error('Error in form submission:', error);
      // Tratar erros de maneira adequada aqui, por exemplo, exibir uma mensagem para o usuário.
    }
  };


  return (
    <>
      <div className="modal-background">
        <div className="modal">
          <h2>Cadastro de usuario</h2>
          <form onSubmit={handleSubmit}>
            <label>
              Nome do Usuario:
              <input
                type="text"
                name="userName"
                value={userData.name}
                onChange={handleUserChange}
                required
              />
            </label>
            <label>
              Numero:
              <input
                type="text"
                name="number"
                value={addressData.number}
                onChange={handleAddressChange}
                required
              />
            </label>
            <label>
              Complemento:
              <input
                type="text"
                name="addressStreet"
                value={addressData.complement}
                onChange={handleAddressChange}
                required
              />
            </label>
            <label>
              Nome de sua Bairro:
              <input
                type="text"
                name="neighborhood"
                value={addressData.neighborhood}
                onChange={handleAddressChange}
                required
              />
            </label>
            <label>
              Nome de sua Cidade:
              <input
                type="text"
                name="city"
                value={addressData.city}
                onChange={handleAddressChange}
                required
              />
            </label>
            <label>
              CEP:
              <input
                type="text"
                name="postalCode"
                value={addressData.postalCode}
                onChange={handleAddressChange}
                required
              />
            </label>
            <div className="addAndCloseBtns">
              <button type="submit">Cadastrar Usuario</button>
            </div>
          </form>
        </div>
      </div>
    </>
  );
}
