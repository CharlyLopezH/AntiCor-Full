//import RuspejPage from "./pages/RuspejPage";
import './App.css'
import IndiceRuspej from './pages/IndiceRuspej';

export  const ACApp = ()=>{

    return(
        <>
        <div className="container">
            <h1>Bienvenido a la Plataforma Anticorrupción</h1>
        </div>
        <div>
        {/* <RuspejPage/> */}
        <IndiceRuspej/>
        </div>
        </>
    )
}

export default ACApp;