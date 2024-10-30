import React from 'react';

export function VendorSelect({ vendedores, selectedVendedor, setSelectedVendedor }) {
    return (
        <div className="mb-4">
            <label htmlFor="vendor-select" className="form-label">Seleccionar Vendedor</label>
            <select
                id="vendor-select"
                className="form-select"
                value={selectedVendedor}
                onChange={(e) => setSelectedVendedor(e.target.value)}
            >
                <option value="">Seleccione un vendedor</option>
                {vendedores.map(vendedor => (
                    <option key={vendedor.id} value={vendedor.id.toString()}>
                        {vendedor.descripcion || 'Nombre no disponible'}
                    </option>
                ))}
            </select>
        </div>
    );
}
