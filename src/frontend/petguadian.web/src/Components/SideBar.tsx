import React, { useState } from 'react'
import './css/siderbar.css'
import { Outlet } from 'react-router-dom'
import PetsIcon from '@mui/icons-material/Pets';
import TextSnippetIcon from '@mui/icons-material/TextSnippet';



export function SideBar() {
    const [activeItem, setActiveItem] = useState<string>('Pets');

    const handleItemClick = (itemName: string) => {
      setActiveItem(itemName);
    };
    return (
        <>
            <div className='sidebar-container'>

                <div className="sidebar">
                    <a className={activeItem === 'Pets' ? 'active' : ''} onClick={() => handleItemClick('Pets')} href="#news">
                        <PetsIcon /> Pets
                    </a>
                    <a className={activeItem === 'Exames' ? 'active' : ''} onClick={() => handleItemClick('Exames')} href="#contact">
                        <TextSnippetIcon/> Exames
                    </a>
                    <a className={activeItem === 'Veterinarios' ? 'active' : ''} onClick={() => handleItemClick('Veterinarios')} href="#contact">
                        Veterinarios
                    </a>
                    <a className={activeItem === 'Sobre' ? 'active' : ''} onClick={() => handleItemClick('Sobre')} href="#about">
                        Sobre
                    </a>
                    <a className={activeItem === 'Contato' ? 'active' : ''} onClick={() => handleItemClick('Contato')} href="#about">
                        Contato
                    </a>
                </div>
                <div>
                    <Outlet />
                </div>
            </div>
        </>
    )
}