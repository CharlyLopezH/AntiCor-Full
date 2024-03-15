import axios from "axios";
import { useEffect, useState } from "react";
import Paginate from "../componentes/Paginate";
import { RuspejDTO } from '../models/ruspej.model';


export const RuspejPage = () => {
       
  const [ruspejData, setRuspejData] = useState<RuspejDTO[]>([]);
  const [currentPage, setCurrentPage] = useState<number>(0);
  const PAGE_SIZE = 15;

  const handleOnMouseOver=()=>{
    console.log('onMouseOver');
  }

  const handlePageClick = (data: { selected: number }) => {
    setCurrentPage(data.selected);
  };

  const getRuspejData = async () => {
    console.log('Recuperando Información de Tabla ruspej desde SQL server');
    try {
      const response = await axios.get('https://localhost:7225/api/Ruspejs');
      setRuspejData(response.data);
    } catch (error) {
      console.log('Error, no se pudo extraer la información ', error);
    }
  };

  useEffect(() => {
    getRuspejData();
  }, []);

  const startIndex = currentPage * PAGE_SIZE;
  const endIndex = startIndex + PAGE_SIZE;
  const currentPageData = ruspejData.slice(startIndex, endIndex);

  return (
    <>
      <div>
        <code>Registro de Servidores que participan en procesos de Adquisiciones y Enajenaciones</code>
        <table className="table table-light table-striped table-hover custom-table">
          <thead className="table-dark">
            <tr>
              <th>ID</th>
              <th>CURP</th>
              <th>Nombre</th>
              <th>Obs</th>
            </tr>
          </thead>
          <tbody>
            {currentPageData.map((ruspejItem) => (
              <tr key={ruspejItem.id}>
                <td>{ruspejItem.id}</td>
                <td className="left-align-text">{ruspejItem.curp}</td>
                <td className="left-align-text">{ruspejItem.nombres.toUpperCase()}</td>
                <td onMouseOver={handleOnMouseOver}>
                {ruspejItem.icono === 'Ok' ? <span role="img" aria-label="icon">🚩</span> : null}  
                {/* <td className="left-align-text">{ruspejItem.icono}</td>   */}
                {/* <span role="img" aria-label="flag">🚩</span> */}
                {/* <td className="left-align-text">{ruspejItem.Icono}</td> */}
                </td>
              </tr>
            ))}
          </tbody>
        </table>

        <Paginate
          pageCount={Math.ceil(ruspejData.length / PAGE_SIZE)}
          onPageChange={handlePageClick}
        />
      </div>
    </>
  );
};
export default RuspejPage;