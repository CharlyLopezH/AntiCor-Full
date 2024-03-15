//Define las rutas de los diferentes endpoints proporcionados por el servicio API en producción o desarrollo
import {getEnvVariables} from "../helpers/getEnvVariables"
const {VITE_API_URL}=getEnvVariables();

console.log(VITE_API_URL);
export const urlIndiceRuspejs = `${VITE_API_URL}/Ruspejs`