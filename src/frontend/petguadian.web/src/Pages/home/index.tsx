import styles from './index.module.css';
import homeImg from '../../assets/home-sembackground.png'
import { NavBar } from '../../Components/NavBar';
import { Sections } from '../../Components/Sections'

export const Home = () => {
    return (
        <>
            <NavBar></NavBar>
            <div className={styles.container}>
                <div className={styles.sub_container}>
                    <section className={styles.cards_section}>
                        <div className={styles.card}>
                            <a className={styles.card_title}>
                                <b>Proteja seus pets</b>
                            </a>
                           
                            <a> Nosso sistema simplifica o controle das vacinas, 
                                garantindo a saúde dos seus amigos peludos.
                            </a>
                        </div>
                        <div className={styles.card}>
                        <a className={styles.card_title}>
                                <b>Informação Instantânea</b>
                            </a>
                           
                            <a> Com nosso app móvel, todas as informações importantes estão sempre ao alcance das suas mãos.
                            </a>
                        </div>
                        <div className={styles.card}>
                        <a className={styles.card_title}>
                                <b>Cuidado Simplificado</b>
                            </a>
                           
                            <a> Simplique o gerenciamento da saúde de pet, garantindo seu bem-estar.
                            </a>
                        </div>

                    </section>
                    <section>
                        <img className={styles.home_image} src={homeImg} alt="" />
                    </section>
                </div>
                <footer>
                    <p>© 2024 Pedro Humberto Gonçalves Cardoso. Todos os direitos reservados.</p>
                </footer>
            </div>
        </>
    )
}

export default Home;