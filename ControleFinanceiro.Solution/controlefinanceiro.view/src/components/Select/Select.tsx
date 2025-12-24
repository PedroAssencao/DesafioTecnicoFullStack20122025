import "./style.css";
interface Option {
  value: string | number;
  label: string;
}

interface SelectProps {
  label?: string;
  value: string | number;
  onChange: (value: string) => void;
  options: Option[];
  required?: boolean;
  className?: string;
}

export default function Select(props: SelectProps) {
  return (
    <div className={`form-group ${props.className || ""}`}>
      {props.label && <label>{props.label}</label>}
      <select
        className="custom-input"
        required={props.required}
        value={props.value}
        onChange={(e) => props.onChange(e.target.value)}
      >
        <option value="">Selecione...</option>
        {props.options.map((opt) => (
          <option key={opt.value} value={opt.value}>
            {opt.label}
          </option>
        ))}
      </select>
    </div>
  );
}
