CREATE PROCEDURE sp_select_note(note_id UUID)
LANGUAGE SQL
AS $$
SELECT notes.*, users.first_name, users.last_name from notes
join users on notes.user_id = users.id
WHERE notes.id = note_id 
$$;
