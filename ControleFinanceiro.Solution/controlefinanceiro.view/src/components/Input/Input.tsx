import "./style.css";

export default function Input(props: {
  label?: string;
  type?: "text" | "number" | "email" | "password" | "date";
  value: string | number;
  onChange: (value: string) => void;
  placeholder?: string;
  required?: boolean;
  className?: string;
  allowNegative?: boolean;
}) {
  const handleInputChange = (inputValue: string) => {
    if (props.type === "number") {
      let cleanedValue = "";

      if (props.allowNegative) {
        cleanedValue = inputValue.replace(/(?!^-)[^0-9]/g, "");
      } else {
        cleanedValue = inputValue.replace(/\D/g, "");
      }
      props.onChange(cleanedValue);
    } else {
      props.onChange(inputValue);
    }
  };

  return (
    <div className={`form-group ${props.className || ""}`}>
      {props.label && <label>{props.label}</label>}
      <input
        className="custom-input"
        type={props.type === "number" ? "text" : props.type || "text"}
        required={props.required}
        value={props.value}
        placeholder={props.placeholder}
        onChange={(e) => handleInputChange(e.target.value)}
      />
    </div>
  );
}
