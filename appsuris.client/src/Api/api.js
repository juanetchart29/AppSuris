import axios from "axios";



const EndpointLocalClient = "http://localhost:5027/api"

export const getVendedores = async () => {
    try {
        const response = await axios.get(`${EndpointLocalClient}/Vendedores`);
        return response.data;
    } catch (error) {
        console.error('Error al obtener vendedores:', error);
        return [];
    }
}
export const getArticulos = async () => {
    try {
        const response = await axios.get(`${EndpointLocalClient}/Articulos`);
        return response.data;
    } catch (error) {
        console.error('Error al obtener articulos:', error);
        return [];
    }
}
export const PostPedido = async (pedido) => {
    try {
        const response = await axios.Post(`${EndpointLocalClient}/Pedido`,pedido);
        return response.data;
    } catch (error) {
        console.error('Error al setear el pedido:', error);
        return [];
    }
}

