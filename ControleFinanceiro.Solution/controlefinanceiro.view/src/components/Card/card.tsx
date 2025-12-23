import type { ReactNode } from "react";
import type { tbodyItem } from "../../types/systemTypes/TableInterface";
import Table from "../Table/Table";
import "./style.css";

export default function Card(props: {
  className?: string;
  hasFooter?: boolean;
  hasHeader?: boolean;
  hasTable?: boolean;
  hasBodyComponent?: boolean;
  BodyComponent?: ReactNode;
  tableHead?: string[];
  tableBodyItems?: tbodyItem[];
  title?: string;
}) {
  return (
    <div className={`card-container ${props.className || ""}`}>
      {props.hasHeader && (
        <div className="card-container-header">
          <h4>{props.title}</h4>
        </div>
      )}
      <div className="card-container-body">
        {props.hasTable && (
          <Table
            Thead={props.tableHead ?? []}
            tbodyItems={props.tableBodyItems ?? []}
          />
        )}
        {props.hasBodyComponent && <>{props.BodyComponent}</>}
      </div>
      {props.hasFooter && <div className="card-container-footer"></div>}
    </div>
  );
}
