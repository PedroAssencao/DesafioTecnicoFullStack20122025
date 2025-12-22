import "./style.css";

export default function Card(props: { className?: string }) {
  return (
    <div className={`card-class ${props.className || ""}`}>
      <h3>Card Component</h3>
    </div>
  );
}
