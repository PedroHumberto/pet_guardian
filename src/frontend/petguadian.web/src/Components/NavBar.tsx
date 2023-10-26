import './css/navbar.css'

export function NavBar() {
    return (
        <>
            <header>
                <div className="logo">
                    <h1>IMAGEM</h1>
                </div>
                <nav className="navbar">
                    <ul>
                        <li>
                            <div className="menubtncontainer">
                                <form action="index.html">
                                    <button className="menubtn">Pagina Inicial</button>
                                </form>
                            </div>
                        </li>
                        <li>
                            <div className="menubtncontainer">
                                <button className="menubtn">Quem Somos</button>
                            </div>
                        </li>
                        <li>
                            <div className="menubtncontainer">
                                <form action="loyalt-card.html">
                                    <button className="menubtn">Nosso Sistema</button>
                                </form>
                            </div>
                        </li>
                        <li>
                            <div className="menubtncontainer">
                                <button className="menubtn">Cadastro</button>
                            </div>
                        </li>
                        <li>
                            <div className="menubtncontainer">
                                <button className="menubtn">Login</button>
                            </div>
                        </li>
                    </ul>
                </nav>
            </header>
        </>
    )
}