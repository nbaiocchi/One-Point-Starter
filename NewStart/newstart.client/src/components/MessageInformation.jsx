import * as React from "react";
import { DismissRegular } from "@fluentui/react-icons";
import {
  MessageBar,
  MessageBarActions,
  MessageBarTitle,
  MessageBarBody,
  MessageBarGroup,
  MessageBarIntent,
  Button,
  Link,
  makeStyles,
  shorthands,
  tokens,
} from "@fluentui/react-components";

const useStyles = makeStyles({
  messageBarGroup: {
    ...shorthands.padding(tokens.spacingHorizontalMNudge),
    display: "flex",
    flexDirection: "column",
    marginTop: "10px",
    ...shorthands.gap("10px"),
    height: "300px",
    ...shorthands.overflow("auto"),
    ...shorthands.border("2px", "solid", tokens.colorBrandForeground1),
  },
  buttonGroup: {
    display: "flex",
    justifyContent: "end",
    ...shorthands.gap("5px"),
  },
});

const intents = ["info", "warning", "error", "success"];

export const MessageInformation = () => {
  const styles = useStyles();

  const counterRef = React.useRef(0);
  const [messages, setMessage] = React.useState([]);

  const showMessage = () => {
    const intent = intents[Math.floor(Math.random() * intents.length)];
    const newMessage = { intent, id: counterRef.current++ };

    setMessage(newMessage);
  };

  const dismissMessage = (messageId) =>
    setMessage((s) => s.filter((entry) => entry.id !== messageId));

  return (
    <>
      <div className={styles.buttonGroup}>
        <Button appearance="primary" onClick={showMessage}>
          Add message
        </Button>
      </div>
      <MessageBar key={`${intent}-${id}`} intent={intent}>
        <MessageBarBody>
          <MessageBarTitle>Descriptive title</MessageBarTitle>
          Message providing information to the user with actionable insights.{" "}
          <Link>Link</Link>
        </MessageBarBody>
        <MessageBarActions
          containerAction={
            <Button
              onClick={() => dismissMessage(id)}
              aria-label="dismiss"
              appearance="transparent"
              icon={<DismissRegular />}
            />
          }
        />
      </MessageBar>
    </>
  );
};

export default MessageInformation;
