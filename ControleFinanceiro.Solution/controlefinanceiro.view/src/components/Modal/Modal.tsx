import "./style.css";

export default function Modal(props: {
  isOpen: boolean;
  onClose: () => void;
  title: string;
  children: React.ReactNode;
  size?: string;
}) {
  if (props.isOpen) {
    document.querySelector("body")?.style.setProperty("overflow", "hidden");
  } else {
    document.querySelector("body")?.style.removeProperty("overflow");
    return null;
  }

  return (
    <div className="modal-overlay">
      <div className={"modal-content " + (props.size || "modal-sg")}>
        <div className="modal-header">
          <h3>{props.title}</h3>
          <button onClick={props.onClose} className="close-button">
            X
          </button>
        </div>
        <div className="modal-body">{props.children}</div>
      </div>
    </div>
  );
}
