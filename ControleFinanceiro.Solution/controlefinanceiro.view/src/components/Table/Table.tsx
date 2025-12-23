import "./style.css";
import { type tbodyItem } from "../../types/systemTypes/TableInterface";
import Button from "../Button/Button";

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
                <Button
                  descricao={"Edit"}
                  className={"button-delete"}
                  onClick={() => row.editFunction?.(row.items[0])}
                />
              </td>
            )}
            {row.deleteFunction != undefined && (
              <td>
                <Button
                  descricao={"Delete"}
                  className={"button-delete"}
                  onClick={() => row.deleteFunction?.(row.items[0])}
                />
              </td>
            )}
          </tr>
        ))}
      </tbody>
    </table>
  );
}
