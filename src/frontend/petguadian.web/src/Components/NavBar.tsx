import styles from './css/navbar.module.css';
import logo from '../assets/Logo.png';

export function NavBar() {
    return (
        <>
            <header>
                <div className={styles.container}>

                    <nav className={styles.navbar}>
                        <ul>
                            <div className={styles.logo}>
                                <img src={ logo } alt="logo" />
                            </div>
                            <li>
                                <div className="menubtncontainer">
                                    <form action="index.html">
                                        <a className="menubtn">Pagina Inicial</a>
                                    </form>
                                </div>
                            </li>
                            <li>
                                <div className="menubtncontainer">
                                    <a className="menubtn">Quem Somos</a>
                                </div>
                            </li>
                            <li>
                                <div className="menubtncontainer">
                                    <form action="loyalt-card.html">
                                        <a className="menubtn">Nosso Sistema</a>
                                    </form>
                                </div>
                            </li>
                            <li>
                                <div className="menubtncontainer">
                                    <a className="menubtn">Cadastro</a>
                                </div>
                            </li>
                            <li>
                                <div className="menubtncontainer">
                                    <a className="menubtn">Login</a>
                                </div>
                            </li>
                        </ul>
                    </nav>
                </div>
            </header>
        </>
    )
}