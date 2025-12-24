import "./style.css";

export default function Input(props: {
  label?: string;
  type?: "text" | "number" | "email" | "password" | "date";
  value: string | number;
  onChange: (value: string) => void;
  placeholder?: string;
  required?: boolean;
  className?: string;
  isCurrency?: boolean;
}) {
  const applyMoneyMask = (value: string) => {
    const cleanValue = value.replace(/\D/g, "");

    if (!cleanValue) return "";

    const result = new Intl.NumberFormat("pt-BR", {
      minimumFractionDigits: 2,
      maximumFractionDigits: 2,
    }).format(parseFloat(cleanValue) / 100);

    return result;
  };

  const handleInputChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    const inputValue = e.target.value;

    if (props.isCurrency) {
      const masked = applyMoneyMask(inputValue);
      props.onChange(masked);
    } else {
      props.onChange(inputValue);
    }
  };

  return (
    <div className={`form-group ${props.className || ""}`}>
      {props.label && <label>{props.label}</label>}
      <div className="input-currency-wrapper">
        <input
          className={`custom-input ${
            props.isCurrency ? "input-with-prefix" : ""
          }`}
          type="text"
          required={props.required}
          value={props.value}
          placeholder={props.placeholder}
          onChange={handleInputChange}
        />
      </div>
    </div>
  );
}
