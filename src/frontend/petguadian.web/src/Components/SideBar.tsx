import React, { Component } from 'react'
import './css/siderbar.css'
import { Outlet } from 'react-router-dom'



export function SideBar()
{
    return(
        <>
            <div className='container'>

                <div className="sidebar">
                    <a className="active" href="#home">Home</a>
                    <a href="#news">Pets</a>
                    <a href="#contact">Exames</a>
                    <a href="#contact">Veterinarios</a>
                    <a href="#about">Sobre</a>
                    <a href="#about">Contato</a>
                </div>
                <div>
                    <Outlet/>
                </div>
            </div>
        </>
    )
}