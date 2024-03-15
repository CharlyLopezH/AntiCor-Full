export interface RuspejDTO {
    id: number;
    curp: string;
    nombres: string;
    icono:string;
    // Agrega una firma (key) de índice para el sort
  [key: string]: any;
  }