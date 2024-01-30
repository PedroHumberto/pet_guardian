import styles from './index.module.css';
import homeImg from '../../assets/home-sembackground.png'
import { NavBar } from '../../Components/NavBar'
import { Sections } from '../../Components/Sections'

export const Home = () => {
    return (
        <>
            <div className={styles.index_container}>
                <NavBar/>
                <img className={styles.home_image} src={ homeImg } alt="Img inicial" />
                <div className={styles.sub_container}> 
                    <div className={styles.page_sections}>
                        <Sections/>
                    </div>
                </div>
            </div>
        </>
    )
}

export default Home;