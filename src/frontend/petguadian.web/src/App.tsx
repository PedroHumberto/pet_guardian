import React from 'react';
import { SideBar } from './Components/SideBar'
import { PetForm } from './Components/PetForm';
import './Components/css/app.css'

function App() {
  return (
    <div className='container'>
      <div className='menu'>
        <SideBar/>
      </div>
      <div className='form'>
        <PetForm/>
      </div>
    </div>
  );
}

export default App;
