import "./style.css";
import { type tbodyItem } from "../../types/systemTypes/TableInterface";

export default function Table(props: {
  Thead: string[];
  tbodyItems: tbodyItem[];
}) {
  return (
    <table className="table-component">
      <thead>
        <tr>
          {props.Thead.map((header, index) => (
            <th key={index}>{header}</th>
          ))}
        </tr>
      </thead>
      <tbody>
        {props.tbodyItems.map((row, rowIndex) => (
          <tr key={rowIndex}>
            {row.items.map((item, itemIndex) => (
              <td key={itemIndex}>{item}</td>
            ))}
            {row.editFunction != undefined && (
              <td>
                <button onClick={() => row.editFunction?.(row.items[0])}>
                  Edit
                </button>
              </td>
            )}
            {row.deleteFunction != undefined && (
              <td>
                <button onClick={() => row.deleteFunction?.(row.items[0])}>
                  Delete
                </button>
              </td>
            )}
          </tr>
        ))}
      </tbody>
    </table>
  );
}
