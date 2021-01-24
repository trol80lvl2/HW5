CREATE PROCEDURE sp_update_note_mark_deleted(note_id UUID)
LANGUAGE SQL
AS $$
UPDATE notes 
set is_deleted = true, modified_at = current_timestamp
WHERE notes.id = note_id 
$$;