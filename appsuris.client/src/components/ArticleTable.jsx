import React from 'react';

export function ArticleTable({ articulos, selectedArticulos, handleArticuloSelect }) {
    return (
        <div className="mb-4 table-responsive">
            <table className="table table-hover">
                <thead className="table-light">
                    <tr>
                        <th scope="col">Seleccionar</th>
                        <th scope="col">Codigo</th>
                        <th scope="col">Descripcion</th>
                        <th scope="col" className="text-end">Precio</th>
                        <th scope="col" className="text-end">Deposito</th>
                    </tr>
                </thead>
                <tbody>
                    {articulos.map(articulo => (
                        <tr key={articulo.codigo}>
                            <td>
                                <div className="form-check">
                                    <input
                                        type="checkbox"
                                        className="form-check-input"
                                        checked={selectedArticulos.includes(articulo.codigo)} 
                                        onChange={() => handleArticuloSelect(articulo.codigo)} 
                                        id={`articulo-${articulo.codigo}`} 
                                    />
                                    <label className="form-check-label" htmlFor={`articulo-${articulo.codigo}`}>
                                        Seleccionar
                                    </label>
                                </div>
                            </td>
                            <td>{articulo.codigo}</td> 
                            <td>{articulo.descripcion}</td>
                            <td className="text-end">${articulo.precio.toFixed(2)}</td>
                            <td className="text-end">{articulo.deposito}</td>
                        </tr>
                    ))}
                </tbody>
            </table>
        </div>
    );
}
