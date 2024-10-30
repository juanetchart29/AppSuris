import React, { useState, useEffect } from 'react';
import { getVendedores, getArticulos, PostPedido } from "./Api/api.js";
import { VendorSelect } from './components/VendedorSelect';
import { ArticleTable } from './components/ArticleTable';
import { OrderSummary } from './components/OrderSummary';
import 'bootstrap/dist/css/bootstrap.min.css';
import 'bootstrap/dist/js/bootstrap.bundle.min.js';

export default function OrderSystem() {
    const [vendedores, setVendedores] = useState([]);
    const [articulos, setArticulos] = useState([]);
    const [selectedVendedor, setSelectedVendedor] = useState("");
    const [selectedArticulos, setSelectedArticulos] = useState([]);

    useEffect(() => {
        async function fetchData() {
            const vendedoresData = await getVendedores();
            const articulosData = await getArticulos();
            setVendedores(vendedoresData);
            setArticulos(articulosData);
        }
        fetchData();
    }, []);

    const handleArticuloSelect = (id) => {
        setSelectedArticulos(prev =>
            prev.includes(id) ? prev.filter(artId => artId !== id) : [...prev, id]
        );
    };

    const handleSubmitOrder = async () => {
        if (selectedArticulos.length === 0) {
            alert('Por favor, seleccione al menos un articulo.');
            return;
        }
        if (!selectedVendedor) {
            alert('Por favor, seleccione un vendedor.');
            return;
        }

        const pedido = {
            vendedorId: parseInt(selectedVendedor, 10), 
            articulosIds: selectedArticulos.map(id => id.toString()), 
            fecha: new Date().toISOString() 
        };

        const response = await PostPedido(pedido); 

        if (response) {
            alert('Pedido generado con exito!');
            setSelectedArticulos([]);
            setSelectedVendedor("");
        } else {
            alert('Error al generar el pedido.');
        }
    };


    return (
        <div className="container-fluid bg-light min-vh-100 py-4">
            <div className="container bg-white shadow rounded">
                <div className="bg-primary text-white p-4 rounded-top">
                    <h1 className="h2">Sistema de Pedidos</h1>
                </div>

                <div className="p-4">
                    <VendorSelect
                        vendedores={vendedores}
                        selectedVendedor={selectedVendedor}
                        setSelectedVendedor={setSelectedVendedor}
                    />
                    <ArticleTable
                        articulos={articulos}
                        selectedArticulos={selectedArticulos}
                        handleArticuloSelect={handleArticuloSelect}
                    />
                    <OrderSummary
                        handleSubmitOrder={handleSubmitOrder}
                    />
                </div>
            </div>
        </div>
    );
}
