import { useState } from "react";
import { RuspejDTO } from "../models/ruspej.model";
import { urlIndiceRuspejs } from "../utils/endpoints";
import IndiceEntidadT from "../utils/IndiceEntidadT";
import { LuArrowUpWideNarrow, LuArrowDownWideNarrow } from "react-icons/lu";
import OverlayTrigger from 'react-bootstrap/OverlayTrigger';
import Tooltip from 'react-bootstrap/Tooltip';

export const IndexRuspejNw = () => {
  //console.log(urlIndiceRuspejs);

  const handleOnMouseOver = () => {
    console.log("Hola, Mouse over field :D; debo poner un tooltip");
  };

  const [sortBy, setSortBy] = useState<{key: string;ascending: boolean;} | null> ({ key: "curp", ascending: false });

  const onHandleSort = (key: string) => {
    console.log("Aquíiii orden... aquí " + key);
    if (sortBy && sortBy.key === key) {
      console.log("ordenaré por " + key);
      //console.log('Estoy en el if del sortBy-->'+'sortBy= '+ sortBy+' sortBy.key= '+key);
      setSortBy({ ...sortBy, ascending: !sortBy.ascending });
    } else {
      setSortBy({ key, ascending: true });
    }
  };

  //Styles
  const ulStyle = {
    textDecoration: "underline",
    color: "blue",
    fontWeight: "normal",
  };

  //Define el ancho de los renglones y tamaño de fuente
  const trStyle= {
    backgroundColor: "lightblue", 
    fontSize: "12px", 
    paddingTop: "10rem", 
    paddingBottom: "0rem",
  }

    //Render Icon
    const renderIcon = (sortByKey: string, ascending: any) => {
        if (sortBy && sortBy.key === sortByKey) {
          return ascending ? <LuArrowUpWideNarrow /> : <LuArrowDownWideNarrow />;
        }
        return null;
      };


  return (
    <>
      <div className="container">
        <IndiceEntidadT<RuspejDTO>
          url={urlIndiceRuspejs}
          nombreEntidad="Indice Ruspej"
          titulo="Ruspej Data"
        >
          {(ruspejData) => (
            <>
              <thead>
                <tr>
                  <th style={ulStyle} onClick={() => onHandleSort("id")}>Id {renderIcon("id", sortBy?.ascending)}</th>
                  <th style={ulStyle} onClick={() => onHandleSort("curp")}>CURP {renderIcon("curp", sortBy?.ascending)}</th>
                  <th style={ulStyle} onClick={() => onHandleSort("nombres")}> Servidor Público {renderIcon("nombres", sortBy?.ascending)}</th>
                  <th>Notas</th>
                </tr>
              </thead>
              <tbody className="table-group-divider">
                {ruspejData
                ?.sort((a, b) => {
                    if (!sortBy) return 0;
                    const order = sortBy.ascending ? 1 : -1;
                    if (a[sortBy.key] < b[sortBy.key]) return -1 * order;
                    if (a[sortBy.key] > b[sortBy.key]) return 1 * order;
                    return 0;
                })
                ?.map((item) => (
                //   <tr style={{backgroundColor: "lightblue", fontSize: "12px", paddingTop: "0rem", paddingBottom: "0rem",}} key={item.id}>
                  <tr style={trStyle} key={item.id}>  
                    <td>{item.id}</td>
                    <td>{item.curp}</td>
                    <td>{item.nombres.toLocaleUpperCase()}</td>
                    <td onMouseOver={handleOnMouseOver}>
                    {item.icono !== "Ok" && (
        <OverlayTrigger placement="top" overlay={<Tooltip id="tooltip">Irregularidades Detectadas: Lorem Ipsum Et al</Tooltip>}
        >
          <span className="d-inline-block" tabIndex={0}>
            <span role="img" aria-label="icon"> 🚩 </span>
          </span>
        </OverlayTrigger>
      )}
                    </td>
                  </tr>
                ))}
              </tbody>
            </>
          )}
        </IndiceEntidadT>
      </div>
    </>
  );
};

export default IndexRuspejNw;
