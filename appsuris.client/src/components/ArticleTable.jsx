import React from 'react'

export function ArticleTable({ articulos, selectedArticulos, handleArticuloSelect }) {
    return (
        <div className="mb-4 table-responsive">
            <table className="table table-hover">
                <thead className="table-light">
                    <tr>
                        <th scope="col">Seleccionar</th>
                        <th scope="col">Nombre</th>
                        <th scope="col">Descripción</th>
                        <th scope="col" className="text-end">Precio</th>
                    </tr>
                </thead>
                <tbody>
                    {articulos.map(articulo => (
                        <tr key={articulo.id}>
                            <td>
                                <div className="form-check">
                                    <input
                                        type="checkbox"
                                        className="form-check-input"
                                        checked={selectedArticulos.includes(articulo.id)}
                                        onChange={() => handleArticuloSelect(articulo.id)}
                                        id={`articulo-${articulo.id}`}
                                    />
                                    <label className="form-check-label" htmlFor={`articulo-${articulo.id}`}>
                                        Seleccionar
                                    </label>
                                </div>
                            </td>
                            <td>{articulo.nombre}</td>
                            <td>{articulo.descripcion}</td>
                            <td className="text-end">${articulo.precio.toFixed(2)}</td>
                        </tr>
                    ))}
                </tbody>
            </table>
        </div>
    )
}