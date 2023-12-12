import React from 'react'
import { SideBarData } from './SideBarData';
import './custom_side_bar.css'
import { Outlet } from 'react-router-dom';

function CustomSideBar() {
  return (
    <div className='principal-container'>
      <div className='sidebar'>
        <ul className='sidebar-list'>
          {
            SideBarData.map((val, key) => {
              return (
                <li key={key}
                  className='row'
                  id={window.location.pathname == val.link ? "active" : ""}
                  onClick={ () => {
                  window.location.pathname = val.link;
                }}>
                  <div id='icon'>
                    {val.icon}
                  </div>
                  <div id='title'>
                    {val.title}
                  </div>
                  
                </li>
              )
            })
          }
        </ul>
      </div>
          <Outlet />
    </div>
  )
}

export default CustomSideBar