import React, { useState } from 'react'
import { VendorSelect } from './components/VendedorSelect'
import { ArticleTable } from './components/ArticleTable'
import { OrderSummary } from './components/OrderSummary'
import 'bootstrap/dist/css/bootstrap.min.css';
import 'bootstrap/dist/js/bootstrap.bundle.min.js';

const vendedores = [
    { id: 1, nombre: "Juan Pérez" },
    { id: 2, nombre: "María García" },
    { id: 3, nombre: "Carlos Rodríguez" },
]

const articulos = [
    { id: 1, nombre: "Laptop", descripcion: "Laptop de alta gama", precio: 1200 },
    { id: 2, nombre: "Mouse", descripcion: "Mouse ergonómico", precio: 50 },
    { id: 3, nombre: "Teclado", descripcion: "Teclado mecánico", precio: 100 },
    { id: 4, nombre: "Monitor", descripcion: "Monitor 4K", precio: 400 },
]

export default function OrderSystem() {
    const [selectedVendedor, setSelectedVendedor] = useState("")
    const [selectedArticulos, setSelectedArticulos] = useState([])

    const handleArticuloSelect = (id) => {
        setSelectedArticulos(prev =>
            prev.includes(id) ? prev.filter(artId => artId !== id) : [...prev, id]
        )
    }

    const handleSubmitOrder = () => {
        if (selectedArticulos.length === 0) {
            alert('Por favor, seleccione al menos un artículo.')
            return
        }
        if (!selectedVendedor) {
            alert('Por favor, seleccione un vendedor.')
            return
        }
        alert('Pedido generado con éxito!')
    }

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
    )
}