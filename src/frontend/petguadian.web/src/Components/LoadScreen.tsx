import React from 'react';
import styles from './css/loadscreen.module.css'; // Supondo que haja um arquivo CSS para estilização

const LoadScreen = () => {
  return (
    <div className={styles.load_screen}>
      <p>Carregando...</p> {/* Mensagem de carregamento */}
      <div className={styles.loader}></div> {/* Elemento que pode ser animado com CSS para mostrar o carregamento */}
    </div>
  );
};

export default LoadScreen;