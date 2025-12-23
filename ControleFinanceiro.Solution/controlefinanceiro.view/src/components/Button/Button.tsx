import "./style.css";

export default function Button(props: {
  descricao: string;
  onClick?: () => void;
  className?: string;
}) {
  return (
    <>
      <button
        className={`custom-button ${props.className || ""}`}
        onClick={props.onClick}
      >
        {props.descricao}
      </button>
    </>
  );
}
