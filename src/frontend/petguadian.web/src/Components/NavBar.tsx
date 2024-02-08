import React, { useState, useEffect, useRef } from 'react';
import styles from './css/navbar.module.css';
import logo from '../assets/Logo.png';
import { Link } from 'react-router-dom';

export function NavBar() {
    const [isSidebarOpen, setIsSidebarOpen] = useState<boolean>(false);
    const [isMobile, setIsMobile] = useState<boolean>(window.innerWidth < 960);
    const navRef = useRef<HTMLDivElement>(null); // Usando genérico HTMLDivElement para a referência

    const toggleSidebar = () => setIsSidebarOpen(!isSidebarOpen);

    useEffect(() => {
        const handleResize = () => setIsMobile(window.innerWidth < 960);
        window.addEventListener('resize', handleResize);
        return () => window.removeEventListener('resize', handleResize);
    }, []);

    // Fechar o menu ao clicar fora
    useEffect(() => {
        const handleClickOutside = (event: MouseEvent) => {
            if (navRef.current && !navRef.current.contains(event.target as Node)) {
                setIsSidebarOpen(false);
            }
        };

        document.addEventListener('mousedown', handleClickOutside);
        return () => document.removeEventListener('mousedown', handleClickOutside);
    }, [navRef]);

    return (
        <header>
            <div className={styles.container} ref={navRef}>
                {isMobile && (
                    <div className={styles.menuToggle} onClick={toggleSidebar}>
                        {/* Ícone de hambúrguer */}
                        <div></div>
                        <div></div>
                        <div></div>
                    </div>
                )}

                <nav className={`${styles.navbar} ${isMobile && isSidebarOpen ? styles.active : ''}`}>
                    <ul className='navbar-content'>
                        <div className={styles.logo}>
                            <img src={logo} alt="logo" />
                        </div>
                        <li>
                            <div className="menubtncontainer">
                                <form action="index.html">
                                    <a className="menubtn">Página Inicial</a>
                                </form>
                            </div>
                        </li>
                        <li>
                            <div className="menubtncontainer">
                                <form action="index.html">
                                    <a className="menubtn">Quem Somos</a>
                                </form>
                            </div>
                        </li>
                        <li>
                            <div className="menubtncontainer">
                                <form action="index.html">
                                    <a className="menubtn">Nosso Sistema</a>
                                </form>
                            </div>
                        </li>
                        <li>
                            <div className="menubtncontainer">
                                <form action="index.html">
                                    <Link to="/login" className="menubtn">Login</Link>
                                </form>
                            </div>
                        </li>
                        <li>
                            <div className="menubtncontainer">
                                <form action="index.html">
                                    <Link to="/singup" className="menubtn">Cadastro</Link>
                                </form>
                            </div>
                        </li>
                        {/* Outros itens do menu */}
                    </ul>
                </nav>
            </div>
        </header>
    );
}
