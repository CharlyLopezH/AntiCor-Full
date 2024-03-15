import axios, { AxiosResponse } from "axios";
import { useEffect, useState } from "react";
import { RuspejDTO } from "../models/ruspej.model";
import { urlIndiceRuspejs } from "../utils/endpoints";
import ListadoGenerico from "../utils/ListadoGenerico";
import Paginacion from "../utils/Paginacion";


export const IndiceRuspej=()=>{

    //console.log(urlIndiceRuspejs);    

const [ruspejData, setRuspejData]=useState<RuspejDTO[]>();
const[totalDePaginas, setTotalDePaginas]=useState(0);
const [recordsPorPagina,setRecordsPorPagina] = useState(15);
const [pagina,setPagina] =useState(1);
const handleOnMouseOver=()=>{
    console.log('Hola, Mouse over field je je');
}
    
useEffect(()=>{
    console.log(urlIndiceRuspejs);
    axios.get(urlIndiceRuspejs, {
        params:{pagina, recordsPorPagina}
    })
    .then((respuesta:AxiosResponse<RuspejDTO[]>)=>{        
        //Conectar la paginación
        const totalDeRegistros = parseInt(respuesta.headers['cantidadtotalregistros'],10);
        setTotalDePaginas(Math.ceil(totalDeRegistros/recordsPorPagina));
          //console.log(respuesta.data);   
          //Respuesta data será enviado a Listado Genérico 
          setRuspejData(respuesta.data);      
    })

},[pagina, recordsPorPagina])

    return(
        <>
        <div className="container">         
        <h3>Registro de Servidores Públicos (RUSPEJ)</h3>

        <div className="form-group" style={{width:'150px'}} > 
        <label>Filas por página</label>
        <select 
            className="form-control"
            defaultValue={10}
            onChange={e=>{
            setPagina(1);
            setRecordsPorPagina(parseInt(e.currentTarget.value,10))}}>
            <option value={10}>10</option>
            <option value={20}>20</option>
            <option value={30}>30</option>
        </select>
        </div>

        <Paginacion 
            cantidadTotalDePaginas={totalDePaginas}
            paginaActual={pagina}
            onChange={nuevaPagina=>setPagina(nuevaPagina)}
        />


        <ListadoGenerico listado={ruspejData} />
        <table className="table table-light table-striped table-hover custom-table ">
            <thead>
                <tr>
                    <th>Id</th>
                    <th>CURP</th>
                    <th>Nombre Completo</th>
                    <th>Notas</th>
                </tr>
            </thead>
            <tbody className="left-align-text">
                {ruspejData?.map(item=>
                    <tr key={item.id}>
                     <td>{item.id}</td>
                     <td>{item.curp}</td>
                     <td>{item.nombres.toLocaleUpperCase()}</td>
                     <td onMouseOver={handleOnMouseOver}>
                       {item.icono === 'Ok' ? <span role="img" aria-label="icon">🚩</span> : null}  
                     </td>

                    </tr>

                    )}
            </tbody>
        </table>

        </div>
        </>
    )
}

export default IndiceRuspej;