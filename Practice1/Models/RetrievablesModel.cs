using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Newtonsoft.Json;

namespace Practice1.Models
{
    public class Metadata
    {

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("uri")]
        public string Uri { get; set; }

        [JsonProperty("etag")]
        public string Etag { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }
    }

    public class Deferred
    {

        [JsonProperty("uri")]
        public string Uri { get; set; }
    }

    public class FirstUniqueAncestorSecurableObject
    {

        [JsonProperty("__deferred")]
        public Deferred Deferred { get; set; }
    }

    public class Deferred2
    {

        [JsonProperty("uri")]
        public string Uri { get; set; }
    }

    public class RoleAssignments
    {

        [JsonProperty("__deferred")]
        public Deferred2 Deferred { get; set; }
    }

    public class Deferred3
    {

        [JsonProperty("uri")]
        public string Uri { get; set; }
    }

    public class AttachmentFiles
    {

        [JsonProperty("__deferred")]
        public Deferred3 Deferred { get; set; }
    }

    public class Deferred4
    {

        [JsonProperty("uri")]
        public string Uri { get; set; }
    }

    public class ContentType
    {

        [JsonProperty("__deferred")]
        public Deferred4 Deferred { get; set; }
    }

    public class Deferred5
    {

        [JsonProperty("uri")]
        public string Uri { get; set; }
    }

    public class GetDlpPolicyTip
    {

        [JsonProperty("__deferred")]
        public Deferred5 Deferred { get; set; }
    }

    public class Deferred6
    {

        [JsonProperty("uri")]
        public string Uri { get; set; }
    }

    public class FieldValuesAsHtml
    {

        [JsonProperty("__deferred")]
        public Deferred6 Deferred { get; set; }
    }

    public class Deferred7
    {

        [JsonProperty("uri")]
        public string Uri { get; set; }
    }

    public class FieldValuesAsText
    {

        [JsonProperty("__deferred")]
        public Deferred7 Deferred { get; set; }
    }

    public class Deferred8
    {

        [JsonProperty("uri")]
        public string Uri { get; set; }
    }

    public class FieldValuesForEdit
    {

        [JsonProperty("__deferred")]
        public Deferred8 Deferred { get; set; }
    }

    public class Deferred9
    {

        [JsonProperty("uri")]
        public string Uri { get; set; }
    }

    public class File
    {

        [JsonProperty("__deferred")]
        public Deferred9 Deferred { get; set; }
    }

    public class Deferred10
    {

        [JsonProperty("uri")]
        public string Uri { get; set; }
    }

    public class Folder
    {

        [JsonProperty("__deferred")]
        public Deferred10 Deferred { get; set; }
    }

    public class Deferred11
    {

        [JsonProperty("uri")]
        public string Uri { get; set; }
    }

    public class ParentList
    {

        [JsonProperty("__deferred")]
        public Deferred11 Deferred { get; set; }
    }

    public class Metadata2
    {

        [JsonProperty("type")]
        public string Type { get; set; }
    }

    public class PredecessorsId
    {

        [JsonProperty("__metadata")]
        public Metadata2 Metadata { get; set; }

        [JsonProperty("results")]
        public object[] Results { get; set; }
    }

    public class ListItem
    {

        [JsonProperty("__metadata")]
        public Metadata Metadata { get; set; }

        [JsonProperty("FirstUniqueAncestorSecurableObject")]
        public FirstUniqueAncestorSecurableObject FirstUniqueAncestorSecurableObject { get; set; }

        [JsonProperty("RoleAssignments")]
        public RoleAssignments RoleAssignments { get; set; }

        [JsonProperty("AttachmentFiles")]
        public AttachmentFiles AttachmentFiles { get; set; }

        [JsonProperty("ContentType")]
        public ContentType ContentType { get; set; }

        [JsonProperty("GetDlpPolicyTip")]
        public GetDlpPolicyTip GetDlpPolicyTip { get; set; }

        [JsonProperty("FieldValuesAsHtml")]
        public FieldValuesAsHtml FieldValuesAsHtml { get; set; }

        [JsonProperty("FieldValuesAsText")]
        public FieldValuesAsText FieldValuesAsText { get; set; }

        [JsonProperty("FieldValuesForEdit")]
        public FieldValuesForEdit FieldValuesForEdit { get; set; }

        [JsonProperty("File")]
        public File File { get; set; }

        [JsonProperty("Folder")]
        public Folder Folder { get; set; }

        [JsonProperty("ParentList")]
        public ParentList ParentList { get; set; }

        [JsonProperty("FileSystemObjectType")]
        public int FileSystemObjectType { get; set; }

        [JsonProperty("Id")]
        public int Id { get; set; }

        [JsonProperty("ID")]
        public int ID { get; set; }

        [JsonProperty("ContentTypeId")]
        public string ContentTypeId { get; set; }

        [JsonProperty("Title")]
        public string Title { get; set; }

        [JsonProperty("Modified")]
        public string Modified { get; set; }

        [JsonProperty("Created")]
        public string Created { get; set; }

        [JsonProperty("AuthorId")]
        public int AuthorId { get; set; }

        [JsonProperty("EditorId")]
        public int EditorId { get; set; }

        [JsonProperty("OData__UIVersionString")]
        public string ODataUIVersionString { get; set; }

        [JsonProperty("Attachments")]
        public bool Attachments { get; set; }

        [JsonProperty("GUID")]
        public string GUID { get; set; }

        [JsonProperty("PredecessorsId")]
        public PredecessorsId PredecessorsId { get; set; }

        [JsonProperty("Priority")]
        public string Priority { get; set; }

        [JsonProperty("Status")]
        public string Status { get; set; }

        [JsonProperty("AssignedToId")]
        public object AssignedToId { get; set; }

        [JsonProperty("AssignedTo")]
        public object AssignedTo { get; set; }

        [JsonProperty("EstimatedHours")]
        public object EstimatedHours { get; set; }

        //projects
        [JsonProperty("Start")]
        public string Start { get; set; }

        [JsonProperty("Finish")]
        public string Finish { get; set; }

        [JsonProperty("percentComplete")]
        public string percentComplete { get; set; }

        [JsonProperty("Work")]
        public string Work { get; set; }

        [JsonProperty("Duration")]
        public string Duration { get; set; }

        [JsonProperty("Owner")]
        public string Owner { get; set; }

        [JsonProperty("LastPublished")]
        public string LastPublished { get; set; }
        //projects


        [JsonProperty("TaskGroupId")]
        public object TaskGroupId { get; set; }

        [JsonProperty("Body")]
        public object Body { get; set; }

        [JsonProperty("StartDate")]
        public string StartDate { get; set; }

        [JsonProperty("DueDate")]
        public object DueDate { get; set; }

        [JsonProperty("RelatedItems")]
        public object RelatedItems { get; set; }

    }

    public class D
    {

        [JsonProperty("results")]
        public ListItem[] Results { get; set; }
    }

    public class ListItemModels
    {

        [JsonProperty("d")]
        public D D { get; set; }
    }
}