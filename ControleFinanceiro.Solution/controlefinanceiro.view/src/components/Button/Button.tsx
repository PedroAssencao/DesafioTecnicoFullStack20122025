import "./style.css";

export default function Button(props: {
  descricao: string;
  onClick?: () => void;
  className?: string;
  typeButton?: "button" | "submit" | "reset";
}) {
  return (
    <>
      <button
        className={`custom-button ${props.className || ""}`}
        onClick={props.onClick}
        type={props.typeButton || "button"}
      >
        {props.descricao}
      </button>
    </>
  );
}
