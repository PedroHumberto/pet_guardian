# Pai de Pet

Nome do Sistema: Pai de Pet (PaidPet)

## Objetivo:

Permitir que o usuario tenha total controle sobre os dados de seu pet, como exames, vacinas, doenças. Será possivel anexar os exames e criar observações para cada exame cadastro, assim como o cadastro de Vacinas e Afins.

Futuramente será criado um menu separado para Veterinarios onde os donos de Pet poderão compartilhar os dados do Pet direto com o veterinario cadastrado.

## Pet

### Create Pet (POST)

Para Criar um Pet é necessario passar o ID do usuario. O Id pode ser recuperado via JWT que vai ser o retorno da requisição da Identity API.

Para mais informações consulte a pasta Identity:
<a href="https://github.com/PedroHumberto/pet_guardian/tree/main/src/services/PetGuardian/PetGuadian.API">Identity API </a>

Request: ``api/v1/Pet/create_pet``
Request Body:
```json
{
  "petName": "string",
  "gender": "string",
  "specie": 1,
  "birthDate": "2024-01-30T01:40:38.153Z",
  "weight": 0,
  "userId": "3fa85f64-5717-4562-b3fc-2c963f66afa6"
}
```

### Delete Pet (POST)

Para deletar um pet é necessario passar no corpo da requisição o Id do Pet que quer deletar e o Id do usuario que está deletando

Request: ``api/v1/Pet/delete``

Request Body:
```json
{
  "petId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
  "userId": "3fa85f64-5717-4562-b3fc-2c963f66afa6"
}
```

### Get All Pet By User Id (GET)


Request: ``api/v1/Pet/get_pets_by_userId?userId={Id}``
Result
```json
[
  {
    "petId": "Id",
    "petName": "string",
    "gender": "F||M",
    "specie": 1,
    "birthDate": "2023-11-30T15:15:22.744",
    "age": 0,
    "weight": 0,
    "medicines": [
      {
        "remedyName": "string",
        "dosage": "string",
        "observations": "string",
        "startDate": "2022-04-22T10:34:23",
        "endDate": "2022-04-22T10:34:23"
      }
    ]
  },
]
```


---

## 