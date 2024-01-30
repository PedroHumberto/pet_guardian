import styles from './css/navbar.module.css';
import logo from '../assets/Logo.png';
import { Link } from 'react-router-dom';

export function NavBar() {
    return (
        <>
            <header>
                <div className={styles.container}>

                    <nav className={styles.navbar}>
                        <ul className='navbar-content'>
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
                                    <Link to="/login" className="menubtn">Login</Link>
                                </div>
                            </li>
                            <li>
                                <div className="menubtncontainer">
                                    <Link to="/singup"className="menubtn">Cadastro</Link>
                                </div>
                            </li>

                        </ul>
                    </nav>
                </div>
            </header>
        </>
    )
}