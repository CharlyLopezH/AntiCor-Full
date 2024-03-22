import { RuspejDTO } from "../models/ruspej.model";
import { urlIndiceRuspejs } from "../utils/endpoints";

import IndiceEntidadT from "../utils/IndiceEntidadT";

export const IndiceRuspej = () => {
  console.log('url: '+urlIndiceRuspejs);

  const handleOnMouseOver = () => {
    console.log("Hola, Mouse over field :D");
    console.log('url: '+urlIndiceRuspejs);
  };

  return (
    <>
      <div className="container">
        <IndiceEntidadT<RuspejDTO>
          url={urlIndiceRuspejs}
          nombreEntidad="Ruspej"
          titulo="Ruspej Data"
        >                    
          {(ruspejData) => (
            <>
              <thead>
                <tr>
                  <th>Id</th>
                  <th>CURP</th>
                  <th>Nombre Completo</th>
                  <th>Notas</th>
                </tr>
              </thead>
              <tbody className="left-align-text">
                {ruspejData?.map((item) => (
                  <tr key={item.id}>
                    <td>{item.id}</td>
                    <td>{item.curp}</td>
                    <td>{item.nombres.toLocaleUpperCase()}</td>
                    <td onMouseOver={handleOnMouseOver}>
                      {item.icono === "Ok" ? (
                        <span role="img" aria-label="icon">
                          🚩
                        </span>
                      ) : null}
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

export default IndiceRuspej;
