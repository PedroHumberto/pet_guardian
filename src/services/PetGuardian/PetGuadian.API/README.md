# Pet Guardian


System Name: Pet Guardian

## Objective:

To allow the user to have complete control over their pet's data, including exams, vaccines, and illnesses. Users can attach exams and create observations for each registered exam, as well as register vaccines and related information.

In the future, a separate menu will be created for veterinarians, where pet owners can directly share their pet's data with the registered veterinarian.

## Pet

### Create Pet (POST)

To create a pet, it is necessary to provide the user ID. The ID can be retrieved via JWT, which will be the return of the Identity API request.

For more information, refer to the Identity folder:
<a href="https://github.com/PedroHumberto/pet_guardian/tree/main/src/services/PetGuardian/PetGuadian.API">Identity API </a>

Request HTTP: ``api/v1/Pet/create_pet``


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

To delete a pet, the request body must contain the ID of the pet to be deleted and the ID of the user who is deleting it.

Request HTTP: ``api/v1/Pet/delete``


Request Body:
```json
{
  "petId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
  "userId": "3fa85f64-5717-4562-b3fc-2c963f66afa6"
}
```

### Get All Pet By User Id (GET)

Request HTTP: ``api/v1/Pet/get_pets_by_userId?userId={Id}``


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

### Get Pet By Id (GET)


Returns only a single pet searched by ID. Note that you must provide the user ID, as it will confirm whether this pet belongs to the chosen user.

Request HTTP: ``api/v1/Pet/get_pet/{userId}/{petId}``

Result
```json
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

```

---

## 