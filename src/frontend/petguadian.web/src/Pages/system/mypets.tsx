import PetForm from "../../Components/PetForm";
import './mypets.css'

export function MyPets()
{
    return (
        <>
            <div className="pet-container">

                <h1>Confira seus Pets Aqui</h1>
                <section>
                    <p>
                        AQUI VAI CONTER UM CARD
                    </p>
                </section>
                <div className="addpet">
                    <h2>Adicione o Pet</h2>
                    <PetForm/>
                </div>

            </div>
        </>
    )
}